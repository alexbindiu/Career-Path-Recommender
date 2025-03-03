import React from "react";
import { Box, Typography } from "@mui/material";
import { motion } from "framer-motion";
import WarningAmberIcon from "@mui/icons-material/WarningAmber";

const DetailsForm = () => {
  const textVariants = {
    hidden: { opacity: 0, x: -50 },
    visible: { opacity: 1, x: 0, transition: { duration: 1 } },
  };
  
  return (
    <Box
      component={motion.div}
      initial="hidden"
      animate="visible"
      variants={textVariants}
      sx={{
        textAlign: "left",
        maxWidth: "800px",
        ml: 8,
        mr: 8,
        mt: 3,
      }}
    >
      <Typography variant="h5" fontWeight={600} gutterBottom>
        I'm here to help you with your career advancement!
      </Typography>

      <Typography variant="body1" gutterBottom>
        After you enter the desired job, I will give you some skills which are a
        must-have, others nice to have, and some considered advanced skills in
        your career.
      </Typography>

      <Typography
        variant="body1"
        sx={{
          display: "flex",
          alignItems: "center",
          textAlign: "left",
          color: "gray",
          mt: 2,
          textShadow: "3px 3px 6px rgba(0,0,0,0.3)",
        }}
      >
        <WarningAmberIcon sx={{ color: "gray", mr: 1 }} />
        Note: For some jobs (e.g., Medic), the response might not be 100%
        accurate.
      </Typography>
    </Box>
  );
};

export default DetailsForm;