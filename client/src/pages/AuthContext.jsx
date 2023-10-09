import React, { createContext } from "react";
import { useContext } from "react";

const AuthContext = createContext();

export function useAuth() {
    return useContext(AuthContext);
}

const AuthProvider = (props) => {
  const [authUser, setAuthUser] = React.useState();
  const [isLoggedIn, setIsLoggedIn] = React.useState(false);

  const value = {
    authUser,
    setAuthUser,
    isLoggedIn,
    setIsLoggedIn,
  };

  return (
  <AuthContext.Provider value={value}>
    {props.children}
  </AuthContext.Provider>)
}

export default AuthProvider;
