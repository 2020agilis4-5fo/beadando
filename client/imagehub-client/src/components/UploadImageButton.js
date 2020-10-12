import React from "react";
import Button from "@material-ui/core/Button";
import SaveIcon from "@material-ui/icons/Save";


export default function UploadImageButton(props) {
  return (
      
    <div>
      <Button
        variant="contained"
        color="secondary"
        startIcon={<SaveIcon />}
      >
        Feltöltés
      </Button>
    </div>
  );
}
