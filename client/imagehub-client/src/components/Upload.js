import React, { useState } from "react";
import "./Upload.css";
import UploadImageButton from "./UploadImageButton";
import ImageSelector from "./ImageSelector";
import UploadSnackbar from "./UploadSnackbar";
import { CircularProgress } from "@material-ui/core";

export default function Upload() {
  let [image, setImage] = useState();
  let [selected, setSelected] = useState(false);
  
  let [open, setOpen] = useState(false);
  let [successful, setSuccessful] = useState(false);
  let [isUploading, setIsUploading] = useState(false);

  return (
    <div className="container--upload">
      <div className="upload__wrapper">
        <ImageSelector
          image={image}
          setImage={setImage}
          setSelected={setSelected}
        />
        {selected && !isUploading && (
          <UploadImageButton
            setSelected={setSelected}
            setImage={setImage}
            image={image}
            setOpen={setOpen}
            setSuccessful={setSuccessful}
            setIsUploading={setIsUploading}
          />
        )}
         {isUploading && <CircularProgress />}
      </div>
      {open && <UploadSnackbar successful={successful} open={open} setOpen={setOpen}/>}
    </div>
  );
}
