using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kafka_Integration
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the consumer in a background thread to listen for messages
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => StartConsumer(_cancellationTokenSource.Token));
        }

        // Method to listen for incoming messages from the Kafka topic
        private void StartConsumer(CancellationToken token)
        {
            // Configure the consumer
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-consumer-group", // A unique ID for the consumer group
                AutoOffsetReset = AutoOffsetReset.Earliest // Start reading from the beginning of the topic
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                // Subscribe to the topic
                consumer.Subscribe("chat-message");

                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        var consumeResult = consumer.Consume(token);

                        // When a message is received, update the UI
                        // We use Invoke to safely update the UI from a different thread
                        this.Invoke((MethodInvoker)delegate {
                            textBox1.AppendText($"Friend: {consumeResult.Message.Value}{Environment.NewLine}");
                        });
                    }
                }
                catch (OperationCanceledException)
                {
                    // The consumer was stopped, which is expected on form closing
                }
                finally
                {
                    consumer.Close();
                }
            }
        }

        // Event handler for the "Send" button
        private async void Button1_Click(object sender, EventArgs e)
        {
            // Configure the producer
            var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
            {
                var message = textBox1.Text;

                if (!string.IsNullOrEmpty(message))
                {
                    try
                    {
                        // Send the message to the "chat-message" topic
                        await producer.ProduceAsync("chat-message", new Message<Null, string> { Value = message });

                        // Display the sent message in the local textbox
                        textBox1.AppendText($"Me: {message}{Environment.NewLine}");
                        textBox1.Clear(); // Clear the input area after sending
                    }
                    catch (ProduceException<Null, string> ex)
                    {
                        MessageBox.Show($"Failed to send message: {ex.Error.Reason}", "Production Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Event handler for the "Cancel" button
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the application
        }

        // Clean up resources when the form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel(); // Signal the consumer to stop
            _cancellationTokenSource?.Dispose();
            base.OnFormClosing(e);
        }

        // These event handlers are not used, but they need to exist if they are
        // referenced in the designer file. The naming is corrected to PascalCase.
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}