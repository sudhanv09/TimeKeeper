import { Route, Routes } from "react-router-dom";
import Nav from "./components/nav";
import Home from "./pages/home";
import Login from "./pages/login";
import Admin from "./pages/admin";
import Register from "./pages/register";
import Dashboard from "./pages/dashboard";
import Reservations from "./pages/reservations";
import { useState } from "react";

const App = () => {
  const [topUserState, setTopUserState] = useState({});
  return (
    <>
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/user" element={<Dashboard topUserState={topUserState}/>} />
        <Route path="/login" element={<Login setTopUserState={setTopUserState}/>} />
        <Route path="/register" element={<Register />} />
        <Route path="/admin" element={<Admin topUserState={topUserState}/>} />
        <Route path="/reserve" element={<Reservations />} />
      </Routes>
    </>
  )
}

export default App;
