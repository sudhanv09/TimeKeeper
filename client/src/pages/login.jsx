import React from "react";
import { useState } from "react";
import axios from "axios";

export default function Login() {

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const postClick = (e) => {
    e.preventDefault();

    axios
      .post("http://localhost:5145/user/login", {
        username,password
      })
      .then((response) => console.log(response));
  };

  return (
    <div className="w-full h-screen flex flex-col justify-center items-center">
      <div className="bg-gray-100 px-10 py-20 rounded-lg border-2 border-black-100">
      <form id="login" method="post" onSubmit={postClick}>
        <h1 className="font-semibold text-5xl">Login</h1>
        <div className="mt-4">
          <label className="text-lg font-medium">Username</label>
          <input
            className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
            placeholder="johndoe"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div>
          <label>Password</label>
          <input
            className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
            placeholder="Password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div className="mt-8 flex justify-between items-center">
          <div>
            <input type="checkbox" id="remember" />
            <label for="remember" className="ml-2 font-medium text-base">
              Remember me!
            </label>
          </div>
          <button className="text-violet-500 font-medium text-base">
            Forgot Password?
          </button>
        </div>
        <div className="mt-8 flex justify-center items-center">
          <button className="py-2 rounded-lg bg-violet-500 text-white text-lg font-bold w-full" type="submit" value="login">
            Sign In
          </button>
        </div>
        </form>
      </div>
    </div>
  );
}
