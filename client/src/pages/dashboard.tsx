import axios from "axios";
import React from "react";
import { api_endpoints, base_url_dev } from "../endpoints";

function CheckInEvent(id: string) {
  var checkInTime= new Date().toISOString()
  axios.post(
    base_url_dev + api_endpoints.staff.checkin, {
    id, checkInTime 
  }
  )
    .then((response) => console.log(response));
  return alert('success')
}

function CheckOutEvent(id: string) {
  var checkOutTime= new Date().toISOString()
  axios.post(
    base_url_dev + api_endpoints.staff.checkout, {
    id, checkOutTime
  }
  )
    .then((response) => console.log(response));
  return alert('success')

}

export default function Dashboard({ topUserState }) {
  return (
    <div className="h-screen flex justify-center items-center space-x-4">
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="login" onClick={() => CheckInEvent(topUserState.data.id)}>
        Check In
      </button>
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="logout"
        onClick={() => CheckOutEvent(topUserState.data.id)}
        >
        Check Out
      </button>
    </div>
  );
}
