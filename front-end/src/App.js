import "./App.css";
import { BASE_URL } from "./constants";
import DetailsForm from "./components/DetailsForm";
import SearchForm from "./components/SearchForm";
import SkillsForm from "./components/SkillsForm";
import { Box, Typography, useMediaQuery } from "@mui/material";
import { motion } from "framer-motion";
import { useState } from "react";
import axios from "axios";

function App() {
  const [allSkills, setAllSkills] = useState([]);
  const [returned, setReturned] = useState(false);
  const [started, setStarted] = useState(false);

  const getSkillsByJob = async (_job, _experience) => {
    await axios
      .get(`${BASE_URL}/skills/filter`, {
        params: {
          jobTitle: String(_job),
          experience: parseInt(_experience, 10),
        },
      })
      .then((response) => {
        setAllSkills(response.data);
        setReturned(true);
      })
      .catch((error) => {
        console.log(error.response.status);
        alert("Something went wrong! Please try again. :)");
        setAllSkills([]);
      });
  };

  const textVariants = {
    hidden: { opacity: 0, x: -50 },
    visible: { opacity: 1, x: 0, transition: { duration: 1 } },
  };

  return (
    <div className="App">
      <Typography
        variant="h3"
        component="h2"
        sx={{
          fontFamily: "'Bebas Neue', sans-serif",
          fontWeight: 700,
          textAlign: "left",
          ml: 7,
          mt: 4,
          color: "#FF4081",
          letterSpacing: 3,
          textShadow: "3px 3px 6px rgba(0,0,0,0.3)",
          "@media (max-width: 1000px)": {
            textAlign: "center",
            ml: 0,
            mb: 3,
          },
        }}
      >
        Career Path Recommender
      </Typography>

      <DetailsForm />

      <Box
        component={motion.div}
        initial="hidden"
        animate="visible"
        variants={textVariants}
        sx={{
          width: "95%",
          height: "100%",
          display: "flex",
          flexDirection: "row",
          alignItems: "center",
          justifyContent: "center",
          marginRight: 2,
          marginLeft: 2,
          p: 2,
          gap: 1,
          borderRadius: "5px",
          "@media (max-width: 1000px)": {
            flexDirection: "column",
          },
        }}
      >
        <SearchForm
          getSkillsByJob={getSkillsByJob}
          setReturned={setReturned}
          index={useMediaQuery("(max-width:700px)") ? 1 : 0}
          setStarted={setStarted}
        />

        <Box
          sx={{
            width: "70%",
            height: "100%",
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
            justifyContent: "center",
            p: 2,
            gap: 1,
            borderRadius: "5px",
            "@media (max-width: 1000px)": {
              width: "90%",
              gap: 3,
            },
            "@media (max-width: 700px)": {
              flexDirection: "column",
              width: "100%",
            },
          }}
        >
          <SkillsForm
            skill_type="Must have"
            index={useMediaQuery("(max-width:700px)") ? 1 : 1}
            skillsList={allSkills.slice(0, 5)}
            returned={returned}
            started={started}
          />
          <SkillsForm
            skill_type="Nice to have"
            index={useMediaQuery("(max-width:700px)") ? 1 : 5}
            skillsList={allSkills.slice(5, 9)}
            returned={returned}
            started={started}
          />
          <SkillsForm
            skill_type="Advanced"
            index={useMediaQuery("(max-width:700px)") ? 1 : -2}
            skillsList={allSkills.slice(9, 14)}
            returned={returned}
            started={started}
          />
        </Box>
      </Box>

      <Typography
        variant="caption"
        color="gray"
        sx={{
          display: "flex",
          position: "relative",
          width: "100%",
          justifyContent: "center",
          alignItems: "flex-end",
          alignContent: "flex-end",
          p: 1
        }}
      >
        © alexbindiu
      </Typography>
    </div>
  );
}

export default App;