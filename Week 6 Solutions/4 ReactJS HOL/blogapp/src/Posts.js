import React, { Component } from "react";
import Post from "./Post";

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false,
      error: null,
    };
  }
  async loadPosts() {
    try {
      const res = await fetch("https://jsonplaceholder.typicode.com/posts");
      if (!res.ok) {
        throw new Error(`Failed to fetch posts: ${res.status}`);
      }
      const data = await res.json();
      const posts = data.map((p) => new Post(p.id, p.title, p.body));
      this.setState({ posts });
    } catch (err) {
      this.setState({ hasError: true, error: err });
      alert(`Error fetching posts: ${err.message}`);
    }
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    this.setState({ hasError: true, error });
    alert(`Component error: ${error.message}`);
    console.error("Error info:", info);
  }

  render() {
    const { hasError, error, posts } = this.state;

    if (hasError) {
      return (
        <div style={{ color: "red" }}>
          <h2>Error occurred</h2>
          {error && <pre>{error.message}</pre>}
        </div>
      );
    }

    return (
      <div>
        <h2>Posts</h2>
        {posts.length === 0 ? (
          <p>Loading...</p>
        ) : (
          posts.map((post) => (
            <div key={post.id} style={{ marginBottom: "20px" }}>
              <h3>{post.title}</h3>
              <p>{post.body}</p>
            </div>
          ))
        )}
      </div>
    );
  }
}

export default Posts;