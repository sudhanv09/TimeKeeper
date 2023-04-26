import React from 'react'
import axios from 'axios';
import { useEffect, useState } from 'react'
import { api_endpoints, base_url_dev } from '../endpoints';


function dayOfWeekAsInteger(day) {
  const dayselect = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"][day] || '';
  return dayselect
}

export default function Home() {
  const [datenow, setDateNow] = useState(new Date());
  const [active, setActive] = useState(0);

  useEffect(() => {
    (async () => {
    const result = await axios(base_url_dev+api_endpoints.staff.active)
    setActive(result.data);  
    })()
  }, [])

  useEffect(() => {
    var timer = setInterval(() => setDateNow(new Date()), 1000)

    return function cleanup()
    {
      clearInterval(timer);
    }
  });

  return (
    <div className='flex flex-col items-center justify-center mt-10 space-y-6'>
      <h1 className='my-4 text-9xl font-bold leading-tight'>
        { datenow.getHours() + ":" + datenow.getMinutes() + ":" + datenow.getSeconds() }
      </h1>
      <h2 className='mb -4 text-xl font-bold '>
        { dayOfWeekAsInteger(datenow.getDay()) + ", " + datenow.toLocaleDateString()}
      </h2>
      <h4 >Login to continue</h4>
      <h4><span className='inline-flex w-4 h-4 bg-green-600 rounded-full'></span> No. Active : {active}</h4>

      <a className='my-6 rounded-md p-2 w-20 bg-white text-black font-semibold text-center' href='/login'>
        Login
      </a >
    </div>
  )
}
