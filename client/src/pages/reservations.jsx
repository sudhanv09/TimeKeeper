import axios from "axios";
import { useEffect, React, useState, useMemo } from "react";
import { api_endpoints, base_url_dev } from "../endpoints";
import ReservationTable from "../components/ReservationTable";
import AddReservation from "../components/AddReservation";

export default function Reservations() {
  const [booking, setBooking] = useState([]);
  const [showModal, setShowModal] = useState();
  useEffect(() => {
    (async () => {
      const result = await axios(base_url_dev + api_endpoints.reserve.base);
      setBooking(result.data);
    })();
  }, []);

  return (
    <div>
      <div className="mt-8 flex justify-end pr-8">
        <button
          className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-5"
          type="submit"
          onClick={() => setShowModal(true)}
        >
          + Add
        </button>
      </div>
      <AddReservation
        isVisible={showModal}
        onClose={() => setShowModal(false)}
      />
      <ReservationTable data={booking} />
    </div>
  );
}
