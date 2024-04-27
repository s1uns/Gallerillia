import { TransitionProps } from "@mui/material/transitions";
import { forwardRef } from "react";
import Slide from "@mui/material/Slide";

export const Transition = forwardRef(
    (
        props: TransitionProps & {
            children: React.ReactElement<any, any>;
        },
        ref: React.Ref<unknown>
    ) => {
        return <Slide direction="up" ref={ref} {...props} />;
    }
);
