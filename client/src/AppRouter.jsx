import { Route, Routes } from "react-router-dom";
import Nav from "./components/nav";
import Home from "./pages/home";
import Login from "./pages/login";
import Admin from "./pages/admin";
import Register from "./pages/register";

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
