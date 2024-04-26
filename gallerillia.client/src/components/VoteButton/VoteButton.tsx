import { FC } from "react";
import styles from "./VoteButon.module.scss";
import {
    BiUpvote,
    BiSolidUpvote,
    BiDownvote,
    BiSolidDownvote,
} from "react-icons/bi";

export interface VoteProps {
    isVoted: boolean;
    isPositive: boolean;
    votesCount: number;
}
export const VoteButton: FC<VoteProps> = (props: VoteProps) => {


    if (!props.isVoted) {
        return (
            <div className={styles["vote-btn"]}>
                <div className={styles["vote"]}>
                    {props.isPositive ? <BiUpvote /> : <BiDownvote />}
                </div>
                <p className={props.isPositive ? styles["vote-count--positive"] : styles["vote-count--negative"]}>{props.votesCount}</p>
            </div>
        );
    }

    if (props.isPositive) {
        return (
            <div className={`${styles["vote-btn"]} ${styles["voted"]}`}>
                <div className={styles["vote"]}>
                    <BiSolidUpvote />
                </div>
                <p className={styles["vote-count--positive"]}>{props.votesCount}</p>
            </div>
        );
    }

    return (
        <div className={`${styles["vote-btn"]} ${styles["voted"]}`}>
        <div className={styles["vote"]}> <BiSolidDownvote /></div>
            <p className={styles["vote-count--negative"]}>{props.votesCount}</p>
        </div>
    );
};
