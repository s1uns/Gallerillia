import { FC, forwardRef, useState } from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

import { IDeleteDialog } from "../../types/interfaces";
import { Transition } from "../../utils/dialogWindowTransition";



export const DeleteDialogWindow: FC<IDeleteDialog> = (props: IDeleteDialog) => {
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
                <DialogTitle
                    fontSize={36}
                >{`Delete this ${props.entityName}?`}</DialogTitle>
                <DialogContent>
                    <DialogContentText
                        fontSize={20}
                        id="alert-dialog-slide-description"
                    >
                        {`Are you sure you want to delete ${props.entityName}?`}{" "}
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button
                        style={{ fontSize: "2rem" }}
                        sx={{ color: "black" }}
                        onClick={handleClose}
                    >
                        Cancel
                    </Button>
                    <Button
                        type="submit"
                        style={{ fontSize: "2rem" }}
                        sx={{ color: "black" }}
                        onClick={() => {
                            props.handleAgree();
                            handleClose();
                        }}
                    >
                        Ok
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};
