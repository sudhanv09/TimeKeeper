
import Link from 'next/link'

export default function Home() {
  return (
    <main className='py-16 px-48'>
      <Link href={"/about"} className="bg-teal-400 text-black py-2 px-4 rounded-md">About</Link>
    </main>
  )
}
