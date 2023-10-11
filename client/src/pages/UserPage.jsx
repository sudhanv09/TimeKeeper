import React from "react";
import { useAuth } from "./AuthContext";

export default function UserPage() {
  const user  = useAuth();
  
  return (
    <div>
      <h1>Hello {user.user.id}</h1>
    </div>
  );
}
