import { FC, ReactNode, forwardRef, useState } from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import Slide from "@mui/material/Slide";
import { TransitionProps } from "@mui/material/transitions";

interface IDialog {
    entityName: string;
    render: (onClick: () => void) => ReactNode;
    handleAgree: () => void;
}

const Transition = forwardRef(function Transition(
    props: TransitionProps & {
        children: React.ReactElement<any, any>;
    },
    ref: React.Ref<unknown>
) {
    return <Slide direction="up" ref={ref} {...props} />;
});

export const DeleteDialogWindow: FC<IDialog> = (props: IDialog) => {
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
                style={{ fontSize: "1.5rem" }}
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
                        Disagree
                    </Button>
                    <Button
                        style={{ fontSize: "2rem" }}
                        sx={{ color: "black" }}
                        onClick={() => {
                            props.handleAgree();
                            handleClose();
                        }}
                    >
                        Agree
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};
