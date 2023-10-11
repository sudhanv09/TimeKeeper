import React from "react";
import { useAuth } from "../pages/AuthContext";
import axios from "axios";

export default function Nav() {
  const { user, dispatch } = useAuth();

  const handleClick = async (e) => {
    e.preventDefault();
    const response = await axios.post("http://localhost:5145/user/logout");

    if (response.status === 200) {
      localStorage.removeItem("user");
      dispatch({ type: "Logout" });
    }
  };
  
  return (
    <div className="h-14 flex items-center justify-between px-16 text-md font-bold">
      <a href="/" className="text-white">
        Home
      </a>
      <ul className="flex items-center space-x-8">
        {!user && (
          <li>
            <a href="/login" className="text-white">
              Login
            </a>
          </li>
        )}
        {user && (
          <div className="space-x-4">
            <a href={`/user/${user.name}`}>Welcome {user.name}</a>
            <button onClick={handleClick}>Logout</button>
          </div>
        )}
      </ul>
    </div>
  );
}
