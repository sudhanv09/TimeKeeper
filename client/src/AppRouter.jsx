import { Route, Routes } from "react-router-dom";
import Home from "./pages/home";
import Login from "./pages/login";
import Admin from "./pages/admin";
import Register from "./pages/register";
import Reservations from "./pages/reservations";
import UserPage from "./pages/UserPage";

const AppRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="user/:userid" element={<UserPage />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/admin" element={<Admin />} />
      {/* <Route path="/reserve" element={<Reservations />} /> */}
    </Routes>
  );
};

export default AppRouter;
