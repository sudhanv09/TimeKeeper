import React from "react";
import { useEffect, useState } from "react";

export default function Home() {
  const [datenow, setDateNow] = useState(new Date());

  useEffect(() => {
    var timer = setInterval(() => setDateNow(new Date()), 1000);

    return function cleanup() {
      clearInterval(timer);
    };
  });

  return (
    <div className="flex flex-col items-center justify-center mt-64 space-y-6">
      <div>
        <h1 className="my-4 text-9xl font-bold leading-tight">
          {datenow.toLocaleTimeString()}
        </h1>
        <h2 className="text-xl font-semibold text-center">
          {datenow.toLocaleDateString("en-US", { weekday: "long" }) +
            ", " +
            datenow.toLocaleDateString()}
        </h2>
      </div>

      <div className="space-x-8 mt-8">
        <a href="/login" role="button" className="btn btn-link">
          Login
        </a>
        <a href="/register" role="button" className="btn btn-active btn-primary">
          Register
        </a>
      </div>
    </div>
  );
}
