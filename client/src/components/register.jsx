import React from "react";

export default function Register() {
  return (
    <div className="w-full h-screen flex flex-col justify-center items-center">
      <div className="bg-gray-100 px-10 py-20 rounded-lg border-2 border-black-100">
        <h1 className="font-semibold text-5xl">Register User</h1>
        <div className="mt-6">
          <label className="text-lg font-medium">Username</label>
          <input
            className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
            placeholder="johndoe"
          />
        </div>
        <div>
          <label className="text-lg font-medium">Password</label>
          <input
            className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
            placeholder="Password"
            type="password"
          />
        </div>
        <div>
          <label className="text-lg font-medium">Confirm Password</label>
          <input
            className="w-full border-2 border-gray-200 rounded-xl p-4 mt-1 bg-transparent"
            placeholder="Password"
            type="password"
          />
        </div>
        <h4 className="mt-4 font-medium text-lg"> Select Schedule</h4>
        <div className="mt-4 flex">
            <div class="flex items-center mr-4">
                <input id="sun-checkbox" type="checkbox" value="0" class="w-4 h-4 border-gray-300 rounded" />
                <label for="sun-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Sunday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="mon-checkbox" type="checkbox" value="1" class="w-4 h-4 border-gray-300 rounded" />
                <label for="mon-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Monday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="tue-checkbox" type="checkbox" value="2" class="w-4 h-4 border-gray-300 rounded" />
                <label for="tue-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Tuesday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="wed-checkbox" type="checkbox" value="3" class="w-4 h-4 border-gray-300 rounded" />
                <label for="wed-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Wednesday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="thu-checkbox" type="checkbox" value="4" class="w-4 h-4 border-gray-300 rounded" />
                <label for="thu-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Thursday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="fri-checkbox" type="checkbox" value="5" class="w-4 h-4 border-gray-300 rounded" />
                <label for="fri-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Friday</label>
            </div>
            <div class="flex items-center mr-4">
                <input id="sat-checkbox" type="checkbox" value="6" class="w-4 h-4 border-gray-300 rounded" />
                <label for="sat-checkbox" class="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300">Saturday</label>
            </div>
        </div>
        <div className="mt-6 flex justify-center items-center">
          <button className="py-2 rounded-lg bg-violet-500 text-white text-lg font-bold w-full">
            Register
          </button>
        </div>
      </div>
    </div>
  );
}
