import React from "react";
import useAuth from './AuthContext'

export default function UserPage() {
  
  const {
    authUser,
    setAuthUser,
    isLoggedIn,
    setIsLoggedIn,
  } = useAuth();

  return (
    <div>
      <h1>Hello</h1>
      <h1>{authUser}</h1>
    </div>
  );
}
