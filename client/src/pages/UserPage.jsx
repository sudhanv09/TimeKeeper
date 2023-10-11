import React, { useEffect } from "react";
import { useAuth } from "./AuthContext";
import axios from "axios";

export default function UserPage() {
  const { user } = useAuth();
  console.log(user);

  const handleCheckin = async () => {
    const checkInTime = new Date().toISOString();
    const userId = user.user.id;

    await axios.post("http://localhost:5145/staff/checkin", {
      userId,
      checkInTime,
    });
  };

  const handleCheckOut = async () => {
    const checkOutTime = new Date().toISOString();
    const userId = user.user.id;

    await axios.post("http://localhost:5145/staff/checkin", {
      userId,
      checkOutTime,
    });
  };

  // useEffect(() => {
  //   axios.get(`http://localhost:5145/staff/${user.user.id}`, {

  //   })
  // }, [])

  return (
    <div>
      <div className="h-1/4 flex justify-between p-8">
        <div className="flex flex-row">
          <div className="space-y-16">
            <h1 className="text-semi-bold text-4xl">Username</h1>
            <div className="space-x-8">
              <button
                className="btn btn-active btn-primary"
                onClick={handleCheckin}
              >
                Check-In
              </button>
              <button
                className="btn btn-active btn-primary"
                onClick={handleCheckOut}
              >
                Check-Out
              </button>
            </div>
          </div>
          <div>
            <h3>User Earnings: </h3>
            <h3>Hours Worked: </h3>
          </div>
        </div>
        <div>Heatmap</div>
      </div>
      {/* User timings Table */}
    </div>
  );
}
