import { FC, useState } from "react";
import styles from "./Picture.module.scss";
import { VoteButton } from "../VoteButton/VoteButton";

export interface PictureProps {
    id: string;
    authorId: string;
    imgUrl: string;
    upVotesCount: number;
    downVotesCount: number;
}

type VoteInfo = {
    voteState: "unvoted" | "upvote" | "downvote";
};

export const Picture: FC<PictureProps> = (props: PictureProps) => {
    const [voteInfo, setVoteInfo] = useState<VoteInfo>({
        voteState: "unvoted",
    });
    return (
        <div className={styles["picture"]}>
            <div className={styles["container"]}>
                <div className={styles["image-container"]}>
                    <img
                        className={styles["image"]}
                        src={props.imgUrl}
                        alt="AlbumPicture"
                    />
                </div>
                <div className={styles["votes"]}>
                    <VoteButton
                        isVoted={voteInfo.voteState == "upvote"}
                        isPositive={true}
                        votesCount={props.upVotesCount}
                    />
                    <VoteButton
                        isVoted={voteInfo.voteState == "downvote"}
                        isPositive={false}
                        votesCount={props.downVotesCount}
                    />
                </div>
            </div>
        </div>
    );
};
