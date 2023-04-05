import React from "react";

function CheckInEvent(){
    var timenow = new Date().toUTCString().replace("UTC", "GMT")
    console.log(timenow)
}

export default function Dashboard() {
  return (
    <div className="h-screen flex justify-center items-center space-x-4">
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="login" onClick={CheckInEvent}>
        Check In
      </button>
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="login">
        Check Out
      </button>
    </div>
  );
}
