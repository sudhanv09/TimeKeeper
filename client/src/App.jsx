import React from "react";
import Nav from "./components/nav";
import AppRouter from "./AppRouter";
import AuthProvider from "./pages/AuthContext";


export default function App() {
  return (
    <div className="bg-gradient-to-b from-gray-900 to-gray-600 bg-gradient-to-r h-screen text-white">
      <AuthProvider>
        <Nav />
        <AppRouter />
      </AuthProvider>
    </div>
  );
}