import React, { useState } from "react";
import axios from "axios";
import { api_endpoints, base_url_dev } from "../lib/endpoints";
import { useNavigate } from "react-router-dom";
import { useSignIn } from "react-auth-kit";
import { useAuth } from "./AuthContext";


export default function Login() {
  const { authUser, setAuthUser, isLoggedIn, setIsLoggedIn } = useAuth();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const reroute = useNavigate();
  const signIn = useSignIn();

  const handleFormSubmit = async (e) => {
    e.preventDefault();
    const response = await axios.post(base_url_dev + api_endpoints.user.login, {
      username,
      password,
    });

    if (response.status === 200) {
      setAuthUser(username);
      setIsLoggedIn(true);

      signIn({
        token: response.data.id,
        expiresIn: 7200,
        tokenType: "Bearer",
        authState: { username, id: response.data.id },
      });

      reroute(`/user/${username}`, { replace: true });
    }
  };

  return (
    <div className="mx-auto max-w-screen-xl px-4 py-16 sm:px-6 lg:px-8">
      <div className="mx-auto max-w-lg">
        <form className="mt-6 mb-0 space-y-4 rounded-lg p-4 shadow-lg sm:p-6 lg:p-8">
          <p className="text-center font-bold text-4xl">
            Sign in to your account
          </p>

          <div className="mt-6 space-y-6">
            <div className="relative">
              <input
                type="text"
                className="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
                placeholder="Enter username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
            </div>
            <div className="relative">
              <input
                type="password"
                className="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
                placeholder="Enter password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
          </div>

          <div className="flex justify-end text-xs dark:text-gray-400">
            <button>Forgot Password?</button>
          </div>

          <button
            type="submit"
            className="block w-full rounded-lg bg-indigo-600 px-5 py-3 text-sm font-medium text-white"
            onClick={handleFormSubmit}
          >
            Sign in
          </button>

          <p className="text-center text-sm text-gray-500">
            No account?
            <a className="underline pl-2" href="/register">
              Sign up
            </a>
          </p>
        </form>
      </div>
    </div>
  );
}
