import React from "react";

export default function Nav()
{
    return (
        <div className="bg-indigo-500 top-0 w-full h-14 flex items-center justify-between px-10">
                <a href="/" className="text-white hover:text-gray-400">Logo</a>
            <ul className="flex items-center space-x-8">
                <li>
                <a href="/reserve" className="text-white hover:text-gray-400">Reservations</a>
                </li>
                <li>
                <a href="/login" className="text-white hover:text-gray-400">Login</a>
                </li>
                <li>
                <a href="/register" className="text-white hover:text-gray-400">Register</a>
                </li>
            </ul>
        </div>
        
    )
}