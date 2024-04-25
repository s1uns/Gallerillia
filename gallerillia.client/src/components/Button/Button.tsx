import { ReactNode, FC } from "react";
import styles from "./Button.module.scss";

type ButtonType = "button" | "submit" | "reset" | undefined;

interface ButtonProps {
    children: ReactNode;
    handleClick?: () => void;
    customStyles?: string;
    type?: ButtonType;
    title: string;
    disabled?: boolean;
}

export const Button: FC<ButtonProps> = (props: ButtonProps) => {
    return (
        <button
            onClick={props?.handleClick}
            className={`${props?.customStyles ? props.customStyles : ""} ${styles.button}`}
            type={props.type}
            title={props.title}
            disabled={props?.disabled}
        >
            {props.children}
        </button>
    );
};
