import * as React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { IUpdateDialog } from "../../types/interfaces";
import { FC, useState } from "react";
import { Transition } from "../../utils/dialogWindowTransition";

export const TitleDialogWindow: FC<IUpdateDialog> = (props: IUpdateDialog) => {
    const [open, setOpen] = useState(false);

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
                open={open}
                TransitionComponent={Transition}
                keepMounted
                onClose={handleClose}
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle fontSize={36}>
                    Manage the {props.entityName}'s title
                </DialogTitle>
                <DialogContent>
                    <DialogContentText fontSize={25}>
                        Enter new title for the {props.entityName}
                    </DialogContentText>
                    <TextField
                        sx={{ fontSize: "2rem" }}
                        autoFocus
                        required
                        inputProps={{
                            sx: {
                                color: "black",
                                fontSize: "2rem",
                            },
                        }}
                        InputLabelProps={{
                            sx: {
                                color: "black",
                                fontSize: "2rem",
                                "&.MuiOutlinedInput-notchedOutline": {
                                    fontSize: "2rem",
                                },
                            },
                        }}
                        margin="dense"
                        id="newTitle"
                        name="newTitle"
                        label="Title name"
                        fullWidth
                        variant="standard"
                        value={props.currentValue}
                        onChange={props.onChangeValue}
                    />
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
                        Submit
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};
