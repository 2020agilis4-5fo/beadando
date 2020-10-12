import React, { useState } from "react";
import "./Upload.css";
import Button from "@material-ui/core/Button";
import { makeStyles } from "@material-ui/core/styles";
import UploadImageButton from "./UploadImageButton";
import ImageSelector from "./ImageSelector";

export default function Upload() {
  let [image, setImage] = useState();
  let [selected, setSelected] = useState(false);

  return (
    <div className="container--upload">
      <div className="upload__wrapper">
        <ImageSelector image={image} setImage={setImage} setSelected={setSelected}/>
        {selected && <UploadImageButton image={image} />}
      </div>
    </div>
  );
}
