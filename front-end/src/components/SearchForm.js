import { React, useState } from "react";
import { Button, FormControl, InputLabel, MenuItem, Paper, Select, TextField, Typography } from "@mui/material";

const SearchForm = ({ getSkillsByJob, setReturned, index, setStarted }) => {
  const [text, setText] = useState("");
  const [level, setLevel] = useState("");
  const [errors, setErrors] = useState({ text: false, level: false });

  const handleJobChange = (e) => {
    setText(e.target.value);
    setErrors((prev) => ({ ...prev, text: false }));
  };

  const handleLevelChange = (e) => {
    setLevel(e.target.value);
    setErrors((prev) => ({ ...prev, level: false }));
  };

  const handleSearch = (e) => {
    e.preventDefault();
    if (!text || !level) {
      setErrors({ text: !text, level: !level });
      return;
    }
    setReturned(false);
    setStarted(true);
    getSkillsByJob(text, level);
  };

  return (
    <Paper
      elevation={4}
      component="form"
      autoComplete="off"
      sx={{
        mt: index * 3,
        width: "250px",
        height: "240px",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        marginRight: 2,
        p: 2,
        gap: 1,
        bgcolor: "#FCFCFF",
        borderRadius: "5px",
        transition:
          "transform 0.3s ease-in-out, width 0.3s ease-in-out, height 0.3s ease-in-out",
        "&:hover": {
          transform: "scale(1.1)",
        },
        "@media (max-width: 1000px)": {
          width: "400px",
        },
        "@media (max-width: 700px)": {
          width: "300px",
        },
        "@media (max-width: 600px)": {
          width: "270px",
        },
      }}
    >
      <Typography
        variant="h5"
        component="div"
        align="center"
        sx={{
          width: "100%",
          height: 60,
          bgcolor: "#EDBBBB",
          color: "white",
          textAlign: "center",
          alignContent: "center",
          borderRadius: "5px 5px 0 0",
        }}
      >
        Your job..
      </Typography>

      <TextField
        fullWidth
        variant="outlined"
        label="Job name.."
        value={text}
        onChange={handleJobChange}
        error={errors.text}
        helperText={errors.text ? "Please enter a job name" : ""}
        InputProps={{
          sx: { textAlign: "center", input: { textAlign: "center" } },
        }}
      />

      <FormControl fullWidth error={errors.level}>
        <InputLabel id="label">Experience..</InputLabel>
        <Select
          fullWidth
          labelId="label"
          value={level}
          onChange={handleLevelChange}
          label="Experience.."
        >
          <MenuItem value={0}>Intern</MenuItem>
          <MenuItem value={1}>Junior</MenuItem>
          <MenuItem value={2}>Mid</MenuItem>
          <MenuItem value={3}>Senior</MenuItem>
        </Select>
        {errors.level && <Typography color="error" variant="caption">Please select an experience level</Typography>}
      </FormControl>

      <Button onClick={handleSearch} variant="contained" fullWidth sx={{ bgcolor: "#FF8780" }}>
        Search
      </Button>
    </Paper>
  );
};

export default SearchForm;
