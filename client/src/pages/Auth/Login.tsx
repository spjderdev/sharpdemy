import { useState, useEffect, useContext } from "react";
import { LoginService } from "../../Features/Auth/Login";
import { User } from "../../Features/Auth/Types";
import { Navigate, useNavigate } from "react-router-dom";
import { AuthContext } from "../../Context/AuthContext";

const Login = () => {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const navigate = useNavigate();
  const authentication = useContext(AuthContext);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (!email || !password) {
      alert("Email and password are required");
      return;
    }

    const user: User = {
      email: email,
      password: password,
    };
    try {
      const token = await LoginService(user);
      if (authentication) {
        authentication.login(token);
        alert("Login successfully");
        console.log(token);
        navigate("/");
      }
    } catch (error: any) {
      alert("Something went wrong, try again");
    }
  };
  return (
    <>
      <h1>Login page</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          type="password"
          name="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button type="submit">Login</button>
      </form>
    </>
  );
};

export default Login;
