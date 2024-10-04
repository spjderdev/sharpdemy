import { createContext, useState, useEffect } from "react";
import Cookies from "js-cookie";
import { jwtDecode } from "jwt-decode";

interface AuthContextType {
  token: string | null;
  login: (token: string) => void;
  name: string | null;
  logout: () => void;
}

const DefaultValue: AuthContextType = {
  token: null,
  login: () => {},
  name: null,
  logout: () => {},
};

export const AuthContext = createContext<AuthContextType | null>(DefaultValue);

interface AuthProviderProps {
  children: React.ReactNode;
}
export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [token, setToken] = useState<string | null>(null);
  const [name, setUsername] = useState<string | null>(null);

  useEffect(() => {
    const storedToken = Cookies.get("token");
    if (storedToken) {
      const decoded: { name: string } = jwtDecode(storedToken);
      console.log(decoded);
      setUsername(decoded.name);
      setToken(storedToken);
    }
  }, []);

  const login = (token: string) => {
    Cookies.set("token", token, { expires: 1 });
    const decoded: { name: string } = jwtDecode(token);
    setUsername(decoded.name);
    setToken(token);
  };

  const logout = () => {
    Cookies.remove("token");
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, login, logout, name }}>
      {children}
    </AuthContext.Provider>
  );
};
