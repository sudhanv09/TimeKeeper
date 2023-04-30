import React from "react";

export default function Nav()
{
    return (
        <div className="bg-transparent top-0 w-full h-14 flex items-center justify-between px-10 text-md font-bold">
                <a href="/" className="text-gray-400 hover:text-gray-400">Logo</a>
            <ul className="flex items-center space-x-8">
                <li>
                <a href="/reserve" className="text-gray-400 hover:text-gray-400">Reservations</a>
                </li>
                <li>
                <a href="/login" className="text-gray-400 hover:text-gray-400">Login</a>
                </li>
            </ul>
        </div>
        
    )
}

export const Profile = () => {
  return (
    <div className="bg-transparent top-0 w-full h-14 flex items-center justify-between px-10 text-md font-bold">
                <a href="/" className="text-gray-400 hover:text-gray-400">Logo</a>
            <ul className="flex items-center space-x-8">
                <li>
                <a href="/reserve" className="text-gray-400 hover:text-gray-400">Reservations</a>
                </li>
                <li>
                <a href="/login" className="text-gray-400 hover:text-gray-400">Logout</a>
                </li>
            </ul>
        </div>
  )
}
