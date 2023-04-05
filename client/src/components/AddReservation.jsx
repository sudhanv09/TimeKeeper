import React from "react";
import { useState } from "react";

const AddReservation = ({ isVisible, onClose }) => {
  if (!isVisible) return null;

  const [name, setName] = useState("");
  const [phone, setPhone] = useState("");
  const [date, setDate] = useState("");
  const [time, setTime] = useState("");

  const postOnClick = () => {};

  const handleClose = (e) => {
    if (e.target.id === "wrapper") onClose();
  };
  return (
    <div
      className="fixed inset-0 backdrop-blur bg-black bg-opacity-20 flex justify-center items-center"
      id="wrapper"
      onClick={handleClose}
    >
      <div className="w-[600px] flex flex-col">
        <div className="bg-white mt-10 mb-0 space-y-4 rounded-lg p-4 shadow-lg sm:p-6 lg:p-8">
          <div>
            <div class="relative">
              <input
                type="text"
                class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                placeholder="Enter name"
                value={name}
                onChange={() => setName(e.target.value)}
              />
            </div>
          </div>
          <div>
            <div class="relative">
              <input
                type="tel"
                class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                placeholder="Enter Phone Number"
                pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}"
              />
            </div>
          </div>
          <div>
            <div class="relative space-x-12">
              <input
                type="date"
                class="rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
              />
              <input
                type="time"
                class="rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
              />
            </div>
            <div>
              <button
                className="py-2 rounded-sm bg-violet-500 mt-6 text-white text-lg font-bold p-5"
                type="submit"
              >
                + Add
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddReservation;
