import axios from "axios";
import React, { useEffect, useMemo, useState } from "react";
import { api_endpoints, base_url_dev } from "../endpoints";
import { useAuthUser } from "react-auth-kit";
import Table from "../components/Table";

function CheckInEvent(id: string) {
  var checkInTime = new Date().toISOString()
  axios.post(
    base_url_dev + api_endpoints.staff.checkin, {
    id, checkInTime
  }
  )
    .then((response) => console.log(response));
  return alert('success')
}

function CheckOutEvent(id: string) {
  var checkOutTime = new Date().toISOString()
  axios.post(
    base_url_dev + api_endpoints.staff.checkout, {
    id, checkOutTime
  }
  )
    .then((response) => console.log(response));
  return alert('success')
}

export default function Dashboard() {
  const authUser = useAuthUser();

  const [state, setState] = useState([])
  useEffect(() => {
    (async () => {
      const result = await axios(base_url_dev + `/staff/${authUser()?.id}`);
      setState(result.data);
    })();
  }, []);

  const columns = useMemo(
    () => [

      {
        Header: "Checkin",
        accessor: "checkIn",
        Cell: ({ value }) => {
          const date = new Date(value);
          const localDate = date.toLocaleDateString();
          const localTime = date.toLocaleTimeString();
          return <span>{localDate + " - " + localTime}</span>;
        },
      },
      {
        Header: "Checkout",
        accessor: "checkOut",
        Cell: ({ value }) => {
          const date = new Date(value);
          const localDate = date.toLocaleDateString();
          const localTime = date.toLocaleTimeString();
          return <span>{localDate + " - " + localTime}</span>;

        },
      },
      {
        Header: "Earnings",
        accessor: "todaysEarnings"
      },
      {
        Header: "Hours",
        accessor: "todaysHours"
      },
      {
        Header: "Total",
        accessor: "totalSalary"
      },
    ], []
  );


  return (
    <div className="h-screen flex justify-center items-center space-x-4">
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="login" onClick={() => CheckInEvent(authUser()?.id)}>
        Check In
      </button>
      <button
        className="py-2 rounded-sm bg-violet-500 text-white text-lg font-bold p-3"
        type="submit"
        value="logout"
        onClick={() => CheckOutEvent(authUser()?.id)}
      >
        Check Out
      </button>
      <div className="">
        <Table columns={columns} data={state} />
      </div>
    </div>
  );
}
