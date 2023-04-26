import { React } from "react";
import { useTable } from "react-table";

export default function Table({ columns, data }) {

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } =
    useTable({ columns, data: data });

  return (
    <div>
      <div className="px-4 pt-3 pb-4 mt-2 rounded-sm">
        <strong className="text-white font-bold text-3xl mx-14">
          Reservations
        </strong>
        <div className="mt-4">
          <table
            {...getTableProps()}
            className="w-full text-center text-sm font-light"
          >
            <thead className="border-b font-medium text-white text-md">
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
                  <tr {...row.getRowProps()} className="mt-6 text-md hover:bg-gray-900">
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
