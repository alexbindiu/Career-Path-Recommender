import { Box, CircularProgress, List, ListItem, ListItemText, Paper, Typography } from "@mui/material";
import React from "react";

const SkillsForm = ({ skill_type, index, skillsList, returned, started }) => {
  const displayList = (returned) => {
    if (started === false)
      return (
        <Typography
          variant="h7"
          component="div"
          align="center"
          sx={{
            width: "100%",
            height: 60,
            bgcolor: "#FCFCFF",
            color: "gray",
            textAlign: "left",
            alignContent: "center",
            borderRadius: "5px 5px 0 0",
          }}
        >
          {"The skills will appear here :)"}
        </Typography>
      );

    if (returned === true)
      return (
        <List
          sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}
        >
          {skillsList.map((item, index) => (
            <ListItem key={index} divider alignItems="flex-start">
              <ListItemText secondary={item} />
            </ListItem>
          ))}
        </List>
      );
    else
      return (
        <Box sx={{ width: "100%", height: "150px" }}>
          <CircularProgress color="inherit" sx={{ mt: 5 }} />
        </Box>
      );
  };

  return (
    <Paper
      elevation={5}
      component="form"
      autoComplete="off"
      sx={{
        mt: index * 3,
        width: "270px",
        height: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
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
      }}
    >
      <Typography
        variant="h6"
        component="div"
        align="center"
        sx={{
          textDecoration: "underline",
          width: "100%",
          height: 60,
          bgcolor: "#FCFCFF",
          color: "#FF8780",
          textAlign: "left",
          alignContent: "center",
          borderRadius: "5px 5px 0 0",
        }}
      >
        {skill_type}:
      </Typography>

      {displayList(returned)}
    </Paper>
  );
};

export default SkillsForm;