import React from 'react'
import { useEffect, useState } from 'react'

export const DateTime = () => {
  var [date, setDate] = useState(new Date());
  useEffect(() => {
    var timer = setInterval(()=>setDate(new Date()), 1000)

    return function cleanup()
    {
      clearInterval(timer)
    }
  });

  return(
    <div className='space-y-2'>
      <p>Time: {date.toLocaleTimeString()}</p>
      <p>Date: {date.toLocaleDateString()}</p>
    </div>
  )
}

export default function Home() {

  

  return (
    <div className='flex flex-col items-center justify-center mt-10 space-y-6'>
      <DateTime />
      <h4>No. Active : </h4>
    </div>
  )
}

export function UserHome()
{
  return (
    <div>
      Logged In
    </div>
  )
}
