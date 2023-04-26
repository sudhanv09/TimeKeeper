import axios from "axios";
import { useEffect, React, useState, useMemo } from "react";
import { api_endpoints, base_url_dev } from "../endpoints";
import Table from "../components/Table";
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

  const columns = useMemo(
    () => [
      {
        Header: "Name",
        accessor: "name",
      },
      {
        Header: "Booking",
        accessor: "booking",
        Cell: ({ value }) => {
          const date = new Date(value);
          const localDate = date.toLocaleTimeString();
          return <span>{localDate}</span>;
        },
      },
      {
        Header: "Phone Number",
        accessor: "phoneNumber",
      },
      {
        Header: "Return Customer",
        accessor: "returnCustomer",
        Cell: ({ value }) => {
          if (value) {
            return (
              <span
                className={`center relative inline-block select-none whitespace-nowrap rounded-lg
                           bg-pink-500 py-2 px-3.5 align-baseline font-sans text-xs font-bold uppercase leading-none text-white`}
              >
                Yes
              </span>
            );
          } else {
            return <span></span>; // Render an empty span if the value is falsy
          }
        },
      },
      {
        Header: "Actions",
        accessor: "actions",
        Cell: ({ row }) => (
          <button className="text-blue-500 hover:text-blue-700">
            <span>
              <svg
                aria-hidden="true"
                fill="currentColor"
                viewBox="0 0 20 20"
                xmlns="http://www.w3.org/2000/svg"
                className="h-5 w-5"
              >
                <path d="M2.695 14.763l-1.262 3.154a.5.5 0 00.65.65l3.155-1.262a4 4 0 001.343-.885L17.5 5.5a2.121 2.121 0 00-3-3L3.58 13.42a4 4 0 00-.885 1.343z"></path>
              </svg>
            </span>
          </button>
        ),
      },
    ],
    []
  );


  

  return (
    <div>
      <div className="mt-8 flex justify-end pr-8">
        <button
          className="middle none center rounded-lg bg-pink-500 py-3 px-6 font-sans text-xs font-bold uppercase text-white shadow-md shadow-pink-500/20 transition-all hover:shadow-lg hover:shadow-pink-500/40 focus:opacity-[0.85] focus:shadow-none active:opacity-[0.85] active:shadow-none disabled:pointer-events-none disabled:opacity-50 disabled:shadow-none"
          data-ripple-light="true"
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
      <Table columns={columns} data={booking} />
    </div>
  );
}
