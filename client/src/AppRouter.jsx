import { Route, Routes } from "react-router-dom";
import Nav from "./components/nav";
import Home from "./pages/home";
import Login from "./pages/login";
import Admin from "./pages/admin";
import Register from "./pages/register";
import Dashboard from "./pages/dashboard";
import Reservations from "./pages/reservations";


const App = () => {
  return (
    <div className="bg-gradient-to-b from-gray-900 to-gray-600 bg-gradient-to-r h-screen text-white">
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="user/:userid" element={<Dashboard />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/admin" element={<Admin />} />
        <Route path="/reserve" element={<Reservations />} />
      </Routes>
    </div>
  )
}

export default App;
