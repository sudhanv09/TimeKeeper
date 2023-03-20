import { Route, Routes } from "react-router-dom";
import Nav from "./components/nav";
import Home from "./components/home";
import Login from "./components/login";
import Admin from "./components/admin";
import Register from "./components/register";

const App = () => {
  return (
    <>
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/admin" element={<Admin />} />
      </Routes>
    </>
  )
}

export default App;
