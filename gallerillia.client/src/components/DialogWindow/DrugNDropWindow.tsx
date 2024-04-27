import * as React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { IUpdateDialog, IUploadDialog } from "../../types/interfaces";
import { FC, useState } from "react";
import { Transition } from "../../utils/dialogWindowTransition";
import UploadImage from "../UploadImage/UploadImage";

export const DrugNDropWindow: FC<IUploadDialog> = (props: IUploadDialog) => {
    const [open, setOpen] = useState(false);
    const [picture, setPicture] = useState<any[]>([]);
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <>
            <>{props.render(handleClickOpen)}</>
            <Dialog
                sx={{
                    "& .MuiDialog-container": {
                        "& .MuiPaper-root": {
                            width: "100%",
                            maxWidth: "5000px",
                            height: "100%",
                            maxHeight: "5000px"
                        },
                    },
                }}
                open={open}
                TransitionComponent={Transition}
                keepMounted
                onClose={handleClose}
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle fontSize={36}>Upload the picture</DialogTitle>
                <DialogContent style={{ width: "20000px" }}>
                    <UploadImage />
                </DialogContent>
                <DialogActions>
                    <Button
                        style={{ fontSize: "2rem" }}
                        sx={{ color: "black" }}
                        onClick={() => {
                            props.handleClose();
                            handleClose();
                        }}
                    >
                        Cancel
                    </Button>
                    <Button
                        style={{ fontSize: "2rem" }}
                        sx={{ color: "black" }}
                        onClick={() => {
                            props.handleAgree();
                            handleClose();
                        }}
                    >
                        Upload
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};
