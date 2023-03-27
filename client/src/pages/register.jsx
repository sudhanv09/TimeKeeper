import axios from "axios";
import React from "react";
import { useState } from "react";

export default function Register() {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [schedule, setSchedule] = useState([]);

  const workSchedule = [
    { value: 0, name: "Sunday" },
    { value: 1, name: "Monday" },
    { value: 2, name: "Tuesday" },
    { value: 3, name: "Wednesday" },
    { value: 4, name: "Thursday" },
    { value: 5, name: "Friday" },
    { value: 6, name: "Saturday" },
  ];

  const postClick = (e) => {
    e.preventDefault();

    axios
      .post("http://localhost:5145/user/create-user", {
        username,email,password,schedule
      })
      .then((response) => console.log(response));
  };

  const selectSchedule = (e) => {
    const { value, checked } = e.target;
    if (checked) {
      setSchedule((schedule) => [...schedule, parseInt(value)]);
    } else {
      setSchedule((schedule) => schedule.filter((e) => e !== value));
    }
  };

  return (
    <div className="w-full h-screen flex flex-col justify-center items-center">
      <div className="bg-gray-100 px-10 py-20 rounded-lg border-2 border-black-100">
        <form action="" id="register" method="post" onSubmit={postClick}>
          <h1 className="font-semibold text-5xl">Register User</h1>
          <div className="mt-6">
            <label className="text-lg font-medium">Username</label>
            <input
              className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
              placeholder="johndoe"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
          </div>
          <div>
            <label className="text-lg font-medium">Email</label>
            <input
              className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
              placeholder="johndoe"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div>
            <label className="text-lg font-medium">Password</label>
            <input
              className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
              placeholder="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <div>
            <label className="text-lg font-medium">Confirm Password</label>
            <input
              className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
              placeholder="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <h4 className="mt-4 font-medium text-lg"> Select Schedule</h4>
          <div className="mt-4 flex">
            {workSchedule.map(({ value, name }, idx) => {
              return (
                <div className="flex items-center mr-4">
                  <input
                    id={value}
                    type="checkbox"
                    value={value}
                    className="w-4 h-4 border-gray-300 rounded"
                    onChange={selectSchedule}
                  />
                  <label
                    htmlFor={value}
                    key={idx}
                    className="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
                  >
                    {name}
                  </label>
                </div>
              );
            })}
          </div>
          <div className="mt-6 flex justify-center items-center">
            <button
              className="py-2 rounded-lg bg-violet-500 text-white text-lg font-bold w-full"
              type="submit"
              value="register"
            >
              Register
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
