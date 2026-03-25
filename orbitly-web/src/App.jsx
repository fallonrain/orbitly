import { useEffect, useState } from "react";
import axios from "axios";

function App() {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    loadFeed();
  }, []);

  async function loadFeed() {
    try {
      const response = await axios.get("http://localhost:5196/api/feed", {
        params: {
          userId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          page: 1,
          pageSize: 5
        }
      });

      const allPosts = [
        ...response.data.recentPosts,
        ...response.data.randomPosts,
        ...response.data.constellationPosts
      ];

      setPosts(allPosts);
    } catch (error) {
      console.error("Erro ao carregar feed:", error);
    }
  }

  return (
    <div style={{ maxWidth: 600, margin: "0 auto" }}>
  {posts.map(p => (
    <div
      key={p.id}
      style={{
        border: "1px solid #333",
        borderRadius: 12,
        padding: 16,
        marginBottom: 16,
        background: "#111",
        color: "#fff"
      }}
    >
      <div style={{ fontSize: 12, opacity: 0.6 }}>
        {p.userId}
      </div>

      <div style={{ fontSize: 16, margin: "8px 0" }}>
        {p.content}
      </div>

      <div style={{ fontSize: 10, opacity: 0.5 }}>
        {new Date(p.createdAt).toLocaleString()}
      </div>
    </div>
  ))}
</div>
  );
}

export default App;