import { React, useMemo } from "react";
import { useTable } from "react-table";

export default function ReservationTable({ data }) {
  const handleEdit = (row) => {

  };

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
                className={`bg-purple-100 text-purple-800 text-xs font-medium mr-2 px-2.5 py-0.5 rounded-full dark:bg-purple-900 dark:text-purple-300`}
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

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } =
    useTable({ columns, data: data });

  return (
    <div>
      <div className="px-4 pt-3 pb-4 mt-2 rounded-sm">
        <strong className="text-gray-700 font-medium mx-14">
          Reservations
        </strong>
        <div className="mt-4">
          <table
            {...getTableProps()}
            className="w-full text-center text-sm font-light"
          >
            <thead className="border-b font-medium text-gray-700">
              {headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map((column) => (
                    <th {...column.getHeaderProps()} className="px-6 py-4">
                      {column.render("Header")}
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody {...getTableBodyProps()}>
              {rows.map((row) => {
                prepareRow(row);
                return (
                  <tr {...row.getRowProps()} className="mt-6 ">
                    {row.cells.map((cell) => {
                      return (
                        <td {...cell.getCellProps()} className="p-4">
                          {cell.render("Cell")}
                        </td>
                      );
                    })}
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
