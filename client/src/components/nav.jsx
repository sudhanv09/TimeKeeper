import React from "react";
import { useAuth } from "../pages/AuthContext";

export default function Nav() {
  const { user } = useAuth();
  return (
    <div className="h-14 flex items-center justify-between px-16 text-md font-bold">
      <a href="/" className="text-white">
        Home
      </a>
      <ul className="flex items-center space-x-8">
        {!user && <li>
          <a href="/login" className="text-white">
            Login
          </a>
        </li>}
        {user && (
            <div className="space-x-4">
                <span>Welcome {user.name}</span>
                <button>Logout</button>
            </div>
        )}
      </ul>
    </div>
  );
}
