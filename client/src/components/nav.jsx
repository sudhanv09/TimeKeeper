import React from "react";

export default function Nav()
{
    return (
        <div className="bg-indigo-500 top-0 w-full h-14 flex items-center justify-between px-4">
                <a href="/" className="text-white hover:text-gray-400">Logo</a>
            <ul className="flex items-centers space-x-2">
                <li>
                <a href="/" className="text-white hover:text-gray-400">Home</a>
                </li>
                <li>
                <a href="/" className="text-white hover:text-gray-400">Login</a>
                </li>
            </ul>
        </div>
        
    )
}