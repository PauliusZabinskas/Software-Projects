import Link from 'next/link';
import React from 'react';

type NavbarProps = {

};

const Navbar: React.FC<NavbarProps> = () => {

    return <div className='flex item-center justify-between sm:px-12 px-2 md:px-24 h-full'>
        <Link href="/" className='flex items-center justify-center h-20'>
            <img src='/logo.png' alt='LeatCode' className='h-full' />
        </Link>
        <div className='flex item-center'>
            <button
                className='bg-brand-orange text-white px-2 py-1 sm:px-4 rounded-md text-sm font-medium
                        hover:text-brand-orange hover:bg-white hover:border-2 hover:border-brand-orange h-20'
            >Sign IN</button>
        </div>
    </div>
}
export default Navbar;