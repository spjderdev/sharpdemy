import { useState, useEffect } from "react";
import { Course } from "./Types";
import { GetAllCourse } from "./Course";
const CourseList = () => {
  const [course, setCourse] = useState<Course[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    const fetch = async () => {
      try {
        const response = await GetAllCourse();
        setCourse(response);
      } catch (error: any) {
        setError(error);
      } finally {
        setLoading(false);
      }
    };
    fetch();
  }, []);
  if (loading) return <h1>Loading</h1>;
  if (error) return <h1>{error}</h1>;
  return (
    <>
      <div>Course List</div>
      <div>
        {course.map((course, index) => (
          <div key={index}>
            <p>{course.imageUrl}</p>
            <p>{course.title}</p>
            <p>{course.description}</p>
            <p>{course.duration}</p>
            <p>{course.price}</p>
            <p>{course.instructorName}</p>
            <p>{course.level}</p>
          </div>
        ))}
      </div>
    </>
  );
};

export default CourseList;
