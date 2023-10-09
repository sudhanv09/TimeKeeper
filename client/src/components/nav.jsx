import React from "react";

export default function Nav()
{
    return (
        <div className="h-14 flex items-center justify-between px-16 text-md font-bold">
                <a href="/" className="text-white">Home</a>
            <ul className="flex items-center space-x-8">
                <li>
                <a href="/reserve" className="text-white">Reservations</a>
                </li>
                <li>
                <a href="/login" className="text-white">Login</a>
                </li>
            </ul>
        </div>
        
    )
}
