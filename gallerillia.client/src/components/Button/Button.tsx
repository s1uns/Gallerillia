import { ReactNode, FC } from "react";
import styles from "./Button.module.scss";

type ButtonType = "button" | "submit" | "reset" | undefined;

interface IButtonProps {
    children: ReactNode;
    handleClick?: () => void;
    customStyles?: string;
    type?: ButtonType;
    title: string;
    disabled?: boolean;
}

export const Button: FC<IButtonProps> = (props: IButtonProps) => {
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
