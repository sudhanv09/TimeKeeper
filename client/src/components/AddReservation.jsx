import React from "react";
import { useState } from "react";
import axios from "axios";
import { api_endpoints, base_url_dev } from "../endpoints";


const AddReservation = ({ isVisible, onClose }) => {
  if (!isVisible) return null;

  const [name, setName] = useState("");
  const [phoneNumber, setPhone] = useState("");
  const [date, setDate] = useState("");
  const [time, setTime] = useState("");

  const postOnClick = (e) => {
   e.preventDefault(); 
   const bookingDate = new Date(`${date}T${time}`).toISOString();
   const id = ""; // empty id
   axios.post(base_url_dev+api_endpoints.reserve.new, {
    id, name, bookingDate, phoneNumber
   })
.then((response) => console.log(response));
  };

  const handleModalClose = (e) => {
    if (e.target.id === "wrapper") onClose();
  };
  return (
    <div
      className="fixed inset-0 backdrop-blur bg-black bg-opacity-20 flex justify-center items-center"
      id="wrapper"
      onClick={handleModalClose}
    >
      <div className="w-[600px] flex flex-col">
        <div className="bg-white mt-10 mb-0 space-y-4 rounded-lg p-4 shadow-lg sm:p-6 lg:p-8">
          <div>
            <div className="relative">
              <input
                type="text"
                className="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                placeholder="Enter name"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </div>
          </div>
          <div>
            <div className="relative">
              <input
                type="tel"
                className="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                placeholder="Enter Phone Number"
                pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}"
                value={phoneNumber}
                onChange={(e)=>setPhone(e.target.value)}
              />
            </div>
          </div>
          <div>
            <div className="relative space-x-12">
              <input
                type="date"
                className="rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                value={date}
                onChange={(e)=>setDate(e.target.value)}
              />
              <input
                type="time"
                className="rounded-lg border-gray-200 p-4 pr-12 text-sm shadow-sm"
                value={time}
                onChange={(e)=>setTime(e.target.value)}
              />
            </div>
            <div>
              <button
                className="py-2 rounded-sm bg-violet-500 mt-6 text-white text-lg font-bold p-5"
                type="submit"
                onClick={postOnClick}
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
