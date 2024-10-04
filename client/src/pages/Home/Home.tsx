import CourseList from "../../Features/Course/CourseList";
import { Link } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../../Context/AuthContext";
const Home = () => {
  const authentication = useContext(AuthContext);
  if (!authentication) {
    return <h1>Loading</h1>;
  }
  const { token, name } = authentication;
  console.log(name);
  return (
    <>
      {token ? (
        <>
          <div style={{ display: "flex", gap: "50px" }}>
            <p>Hello thang cho {name} </p>
            <Link to="/account">Quan ly tai khoan ne</Link>
            <Link to="/" onClick={() => authentication.logout()}>
              Thoat tai khoan di tk cho
            </Link>
          </div>
          <h1>May da dang nhap</h1>
          <CourseList />
        </>
      ) : (
        <>
          <div style={{ display: "flex", gap: "50px" }}>
            <Link to="/login">Login</Link>
            <Link to="/register">Register</Link>
          </div>
          <h1>May chua dang nhap</h1>
          <CourseList />
        </>
      )}
    </>
  );
};

export default Home;
